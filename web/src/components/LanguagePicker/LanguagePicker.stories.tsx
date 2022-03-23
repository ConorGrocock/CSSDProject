import React from 'react';

import {ComponentMeta, ComponentStory} from '@storybook/react';
import LanguagePicker from "./LanguagePicker";

export default {
    title: 'Components/LanguagePicker',
    component: LanguagePicker,
    argTypes: {},
} as ComponentMeta<typeof LanguagePicker>;

const Template: ComponentStory<typeof LanguagePicker> = ({...args}) => {
    return <LanguagePicker {...args} />;
};

export const Default = Template.bind({});